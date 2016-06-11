
function convertionToRouteModel(list) {
    var renderList = [];
    list.forEach(function (result, index) {
        renderList.push(new Route(100, [result.LocLalitudeStart, result.LocLalitudeEnd], [result.LocLongitudeStart, result.LocLongitudeEnd], result.ColorIndex - 1));
    });
    return renderList;
}