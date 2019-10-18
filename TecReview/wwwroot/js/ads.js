
var incomingList = [{
        "t": 1541269796,
    "hash": "bc9yxeefu",
        }, {
        "t": 1541278805,
    "hash": "bzjib88jd",
        }, {
        "t": 1541279046,
    "hash": "bzj5off97",
        }, {
        "t": 1541279342,
    "hash": "bcpib88jd",
        }, {
        "t": 1541279595,
    "hash": "bc50xeefu",
}];

var randomAdvertise = Math.round(Math.random() * (incomingList.length - 1));

var bannersnack_embed = {
    "hash": incomingList[randomAdvertise].hash,
    "width": 728,
    "height": 80,
    "t": incomingList[randomAdvertise].t,
    "userId": 38365105,
    "type": "html5"
};