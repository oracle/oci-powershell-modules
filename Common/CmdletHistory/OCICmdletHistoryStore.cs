/**
 * Copyright (c) 2020, 2026, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.CompilerServices;

namespace Oci.PSModules.Common.Cmdlets.CmdletHistory
{
    ///<summary>
    ///Singleton class that manages the history of OCI Rest API Responses received
    ///by last few OCI Cmdlets along with their invocation context.
    ///</summary>
    public sealed class OCICmdletHistoryStore
    {
        #region staticmembers
        public static OCICmdletHistoryStore Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SingletonLock)
                    {
                        if (instance == null)
                        {
                            instance = new OCICmdletHistoryStore();
                        }
                    }
                }
                return instance;
            }
        }

        private static readonly object SingletonLock = new object();

        private static OCICmdletHistoryStore instance;
        #endregion

        #region public members
        /// <summary>
        /// Size of the history store. Can be modified by Set-OCICmdletHistory Cmdlet.  
        /// </summary>
        public int Size { get; private set; } = 20;

        /// <summary>
        /// Stores a copy of the last invoked Cmdlets last API response for easy access
        /// </summary>
        public PSObject LastResponse { get; private set; }

        /// <summary>
        /// Property facilitating array access to the queue history store 
        /// </summary>
        public OCICmdletHistory[] Entries
        {
            get { return history.ToArray(); }
        }

        public static string SessionHistoryVarName = "OCICmdletHistory";
        public const int MIN_SIZE = 1;
        public const int MAX_SIZE = 100000;
        #endregion

        #region private members
        private Queue<OCICmdletHistory> history;
        #endregion

        #region constructor
        private OCICmdletHistoryStore()
        {
            history = new Queue<OCICmdletHistory>(Size);
        }
        #endregion

        #region methods
        /// <summary>
        /// OCICmdlet class calls this method on the singleton instance to update the history store.
        /// </summary>
        /// <param name="HistoryInstance">Cmldte history object</param>
        /// <param name="CurrentSession">Current PS session object</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Update(in OCICmdletHistory historyInstance, SessionState currentSession)
        {

            if (history.Count == Size)
            {
                history.Dequeue();
            }
            history.Enqueue(historyInstance);
            LastResponse = historyInstance?.Response;
            UpdateSessionHistory(currentSession);

        }

        /// <summary>
        /// Resize the history store capacity
        /// </summary>
        /// <param name="NewSize">Size of the new history store</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ChangeSize(int newSize)
        {
            //out of bounds check
            if (newSize < MIN_SIZE || newSize > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException($"Requested size {newSize} greater than allowed  bounds {MIN_SIZE} - {MAX_SIZE}");
            }
            int oldCount = history.Count;
            int removeCount = 0;
            if (oldCount > newSize) //shrink
            {
                removeCount = oldCount - newSize;
            }
            if (Size != newSize)
            {
                Queue<OCICmdletHistory> oldHistory = history;
                history = new Queue<OCICmdletHistory>(newSize);
                //remove old elements that won't fit
                while (removeCount > 0)
                {
                    oldHistory.Dequeue();
                    removeCount--;
                }
                //copy the rest to the new queue
                while (oldHistory.Count > 0)
                {
                    history.Enqueue(oldHistory.Dequeue());
                }
                Size = newSize;
            }
        }

        /// <summary>
        /// Clears the stored cmdlet history
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ClearHistory()
        {
            history.Clear();

        }

        /// <summary>
        /// If not already available, this method updates the session variable to hold the singleton reference.
        /// </summary>
        /// <param name="CurrentSession">Current PS Session object</param>
        private void UpdateSessionHistory(SessionState CurrentSession)
        {
            if (CurrentSession.PSVariable.Get(SessionHistoryVarName) == null)
            {
                CurrentSession.PSVariable.Set(SessionHistoryVarName, Instance);
            }
        }
        #endregion
    }
}