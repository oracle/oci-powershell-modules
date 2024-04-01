$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 

function SseResponseHelper {
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [System.IO.Stream] $Stream
    )
    process {
        $StreamReader = New-Object System.IO.StreamReader($Stream)

        $Template='data: {"id":"(?<id>.*)","text":"(?<text>.*)"}'

        while(!$StreamReader.EndOfStream) {
            if($StreamReader.ReadLineAsync().Result -match $Template) { 
                Write-Host -NoNewline $matches['text'].replace("\n", "`n").replace('\"', '"')
            }
        }
    }
}

try {

    Import-Module OCI.PSModules.Generativeaiinference

    $InferenceRequest = New-Object Oci.GenerativeaiinferenceService.Models.CohereLlmInferenceRequest
    $InferenceRequest.IsStream="true"
    $InferenceRequest.Prompt="Tell me a fact about the Earth"
    $InferenceRequest.MaxTokens=1000
    $InferenceRequest.Temperature=0.75
    $InferenceRequest.FrequencyPenalty=1.0
    $InferenceRequest.TopP=0.7
    $InferenceRequest

    $ServingMode = New-Object Oci.GenerativeaiinferenceService.Models.OnDemandServingMode
    $ServingMode.ModelId="cohere.command"

    $GenerateTextDetails = New-Object Oci.GenerativeaiinferenceService.Models.GenerateTextDetails
    # TODO fill out the compartment id below
    $GenerateTextDetails.CompartmentId = "<CompartmentId>"
    $GenerateTextDetails.ServingMode = $ServingMode
    $GenerateTextDetails.InferenceRequest = $InferenceRequest
    $GenerateTextDetails

    New-OCIGenerativeaiinferenceText -GenerateTextDetails $GenerateTextDetails -AuthType SessionToken -HttpCompletionOption ResponseHeadersRead | SseResponseHelper

} finally {
    $ErrorActionPreference = $UserErrorActionPreference
}
