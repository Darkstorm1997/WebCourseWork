
var map = null;


function LoadMap(mapId, location) {
    map = new Microsoft.Maps.Map(mapId, {
        credentials: "AglcOvofpKm1X-WOXDY3_Cr0bxdAbKzUid-4bp7Em3BxbNPK_kT-X8iWI4B1RF0H",
        showMapTypeSelector: false,
        showZoomButtons: false,
        showLocateMeButton: false
    });

    Microsoft.Maps.loadModule('Microsoft.Maps.Search', function () {
        var searchManager = new Microsoft.Maps.Search.SearchManager(map);
        var requestOptions = {
            bounds: map.getBounds(),
            where: decodeHtml(location),
            callback: function (answer, userData) {
                map.setView({ bounds: answer.results[0].bestView });
                map.entities.push(new Microsoft.Maps.Pushpin(answer.results[0].location))
            }
        };
        searchManager.geocode(requestOptions);
    });
}

function LoadMapAndSuggest(mapId, location, locationSearch, locationContainer) {
    LoadMap(mapId, location)
    SuggestLocations(locationSearch, locationContainer)
}

function SuggestLocations(locationSearch, locationContainer) {
    Microsoft.Maps.loadModule('Microsoft.Maps.AutoSuggest', function () {
        var options = {
            maxResults: 4,
            map: map
        };
        var manager = new Microsoft.Maps.AutosuggestManager(options);
        manager.attachAutosuggest(locationSearch, locationContainer, selectedSuggestion);
    });
}

function selectedSuggestion(suggestionResult) {
    map.entities.clear();
    map.setView({ bounds: suggestionResult.bestView });
    var pushpin = new Microsoft.Maps.Pushpin(suggestionResult.location);
    map.entities.push(pushpin);
}