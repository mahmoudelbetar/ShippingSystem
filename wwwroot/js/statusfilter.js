let statusList = document.getElementById("statusList");
let id;
let reportTable = document.getElementById("reportTable");

function FilterStatus(element) {
    id = element.value;
    console.log(id);
    $.ajax({
        url: `/Orders/OrderReport?statusId=${id}`,
        type: "GET",
        success: function (data) {
            var origin = window.location.origin;
            var path = window.location.pathname;
            window.location.href = `${origin}${path}?statusId=${id}`;
            statusList.value = id;
        }
    })
}