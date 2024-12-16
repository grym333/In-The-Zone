//InTheZone.Services
public class PredictionService : IPredictionService
{
    private readonly string _projectId;
    private readonly string _location;
    private readonly string _endpointId;
    private readonly string _apiVersion;
    private readonly PredictionServiceClient _predictionServiceClient;
    private readonly GoogleCredential _credential;

    public PredictionService(IConfiguration configuration)
    {
        _projectId = configuration["ProjectId"];
        _location = configuration["Location"];
        _endpointId = configuration["EndpointId"];
        _apiVersion = configuration["ApiVersion"];
        string jsonPath = configuration["JsonPath"];
        _credential = GoogleCredential.FromFile(jsonPath);

        var clientBuilder = new PredictionServiceClientBuilder
        {
            Endpoint = $"{_location}-aiplatform.googleapis.com",
            Credentials = _credential
        };

        _predictionServiceClient = clientBuilder.Build();//.WithScopes(Google.Apis.Auth.OAuth2.GoogleClientSecrets.Default.Scopes);
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
            Instances = { new Google.Cloud.AIPlatform.V1.PredictRequest.Types.Instance() {  // Prepare instances based on input data 
                Inputs = Google.Protobuf.JsonParser.Default.Parse<Google.Protobuf.Value>(input.ToJson())
            } },
        };
        //3. Call the Vertex AI service 
        PredictResponse response = await _predictionServiceClient.PredictAsync(request);
        // Interpret and return the prediction results 
        return FormatPredictionResult(response);
    }
    private string FormatPredictionResult(PredictResponse response)
    {
        // Process the prediction response and format the result as needed.
        // This example assumes the prediction is a simple string.  Adjust as needed for your model's output.
        return Google.Protobuf.JsonParser.Default.Print(response.Predictions[0]);
    }
}
    public interface IPredictionService
    {
        Task<string> PredictPitchOutcomeAsync(Model input);
    }
    public class Model
    {
        public string PitchType { get; set; }
        public int Velocity { get; set; }
        public int SpinRate { get; set; }
        // Add other relevant features
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
