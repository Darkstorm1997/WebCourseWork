var map = null;

function LoadMap() {
    map = new Microsoft.Maps.Map('#my-map', {
        credentials: "AglcOvofpKm1X-WOXDY3_Cr0bxdAbKzUid-4bp7Em3BxbNPK_kT-X8iWI4B1RF0H"
    });

    var url = "/Statistics/Locations";
    var locations = [];
    var count = 0;
    $.getJSON(url, null, function (data) {
        $.each(data, function (index, LocationName) {
            Microsoft.Maps.loadModule('Microsoft.Maps.Search', function () {
                var searchManager = new Microsoft.Maps.Search.SearchManager(map);
                var requestOptions = {
                    bounds: map.getBounds(),
                    where: LocationName,
                    callback: function (answer, userData) {
                        map.entities.push(new Microsoft.Maps.Pushpin(answer.results[0].location))
                        locations.push(answer.results[0].location)
                        count++

                        if (count == data.length) {
                            map.setView({ bounds: Microsoft.Maps.LocationRect.fromLocations(locations) });
                        }
                    }
                };
                searchManager.geocode(requestOptions);
            });
        });
    });
}
