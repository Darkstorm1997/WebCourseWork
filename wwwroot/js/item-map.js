var map = null;

function LoadMap() {
    map = new Microsoft.Maps.Map('#itemMap', {
        credentials: "AglcOvofpKm1X-WOXDY3_Cr0bxdAbKzUid-4bp7Em3BxbNPK_kT-X8iWI4B1RF0H",
        showMapTypeSelector: false,
        showZoomButtons: false,
        showLocateMeButton: false
    });

    Microsoft.Maps.loadModule('Microsoft.Maps.Search', function () {
        var searchManager = new Microsoft.Maps.Search.SearchManager(map);
        var requestOptions = {
            bounds: map.getBounds(),
            where: decodeHtml("@Model.Location"),
            callback: function (answer, userData) {
                map.setView({ bounds: answer.results[0].bestView });
                map.entities.push(new Microsoft.Maps.Pushpin(answer.results[0].location))
            }
        };
        searchManager.geocode(requestOptions);
    });
}