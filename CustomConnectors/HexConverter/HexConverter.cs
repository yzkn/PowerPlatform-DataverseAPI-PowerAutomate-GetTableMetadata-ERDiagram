public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        
        var contentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);
        var contentAsJson = JObject.Parse(contentAsString);
        var value = (string)contentAsJson["content"];

        byte[] data = Encoding.UTF8.GetBytes(value);
        string hexString = BitConverter.ToString(data).Replace("-", "");

        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent("{\"content\": \"" + hexString + "\"}");
        return response;
    }
}
