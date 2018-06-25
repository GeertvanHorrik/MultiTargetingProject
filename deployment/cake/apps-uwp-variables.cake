#l "./buildserver.cake"

var WindowsStoreAppId = GetContinuaCIVariable("WindowsStoreAppId", string.Empty);
var WindowsStoreClientId = GetContinuaCIVariable("WindowsStoreClientId", string.Empty);
var WindowsStoreClientSecret = GetContinuaCIVariable("WindowsStoreClientSecret", string.Empty);
var WindowsStoreTenantId = GetContinuaCIVariable("WindowsStoreTenantId", string.Empty);

var UwpApps = UwpAppsToBuild ?? new string[] { };