//InTheZone.Services
public class PredictionService : IPredictionService
{
    private readonly string _projectId;
    private readonly string _location;
    private readonly string _endpointId;
    private readonly string _apiVersion;
    private readonly PredictionServiceClient _predictionServiceClient;

    public PredictionService(IConfiguration configuration)
    {
        _projectId = configuration["ProjectId"];
        _location = configuration["Location"];
        _endpointId = configuration["EndpointId"];
        _apiVersion = configuration["ApiVersion"];

        var clientBuilder = new PredictionServiceClientBuilder
        {
            Endpoint = $"{_location}-aiplatform.googleapis.com"
        };

        _predictionServiceClient = clientBuilder.Build();
    }

    // Implement interface methods here to interact with Vertex AI
    // For example, a method for predicting pitch outcomes

    public async Task<string> PredictPitchOutcomeAsync(Model input)
    {
         //1. Configure the endpoint to use for prediction
         var endpoint = $"projects/{_projectId}/locations/{_location}/endpoints/{_endpointId}";

         //2. Structure the request payload for prediction, this example would contain a json of features.
          var request = new PredictRequest
                {
                     Endpoint = endpoint,
                     Instances = { /* Prepare instances based on input data */ }, 
                 };
          //3. Call the Vertex AI service 
          PredictResponse response = await _predictionServiceClient.PredictAsync(request);
            // Interpret and return the prediction results 
            return FormatPredictionResult(response);
    }
}