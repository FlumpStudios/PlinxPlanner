namespace PlinxPlanner.API.Tests.MockData
{
    public static class MockJson
    {
        public static string mockAppSettings = "{ 'API': { 'Title': 'Test API Name', 'Description': 'Mock Descrption for testing' }, 'Authentication': { 'defaultScheme': 'Bearer', 'authority': 'http://testhost', 'requireHttpsMetadata': false, 'apiName': 'Test API Name' },'Caching': {'memorySizeLimit': 500}, 'Swagger': { 'Enabled': true, 'Auth': { 'oauthClientId': 'testClientId', 'displayName': 'testDisplayName', 'securityDefinitionName': 'oauth2', 'authorizationUrl': 'http://testhost/connect/authorize', 'flowType': 'implicit', 'scopes': { 'scopeName': 'testScopeName', 'friendlyName': 'Test Friendly Name' } } }, 'Database': { 'ConnectionString': 'testConectionString', 'UseInMemoryDatabase': false, 'SeedDbOnCreate': true } } ";
    }
}
