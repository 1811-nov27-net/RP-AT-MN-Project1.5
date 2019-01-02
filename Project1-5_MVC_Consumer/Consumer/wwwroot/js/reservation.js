/*$('#StartDate').change(function () {
    let date = $(this).val();
    console.log("before change");
    getAvailablesRooms(date);
    console.log("after change");
});*/
$('#StartDate').blur(function () {
    let date = $(this).val();
    console.log(date);
    console.log("before blur");
    getAvailablesRooms(date);
    console.log("after blur");
});

function getAvailablesRooms(date) {
    console.log(date);
    $.get("/Rooms/GetAvailableRoomSelectBoxAsync/" + date, function (data) {
        console.log(data);
        $('#RoomId').html(data);
    });
}