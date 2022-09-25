let datatables;


$(document).ready(function () {
    var url = window.location.search;
    var stat = url.split("=");
    stat = stat[1];
    switch (stat) {
        case "pending":
            loadDataTable("pending");
            break;
        case "inprocess":
            loadDataTable("inprocess");
            break;
        case "completed":
            loadDataTable("completed");
            break;
        default:
            loadDataTable("all");
    }

});

function loadDataTable(status) {
    datatables = $('#tblData').DataTable({
        "ajax": {
            "url": `/Orders/GetAllOrders?status=${status}`
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "orderDate", "width": "5%" },
            { "data": "customerName", "width": "5%" },
            { "data": "firstPhone", "width": "5%" },
            { "data": "governorate.governorateName", "width": "5%" },
            { "data": "city.cityName", "width": "5%" },
            { "data": "orderCost", "width": "5%" },
            {
                "data": "id",
                "render": function (id) {
                    return `
                        <div class=" w-75 btn-group" role="group">
                            <a href="/Orders/Edit?orderId=${id}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square">Edit</i>
                            </a>   
                        </div>
                    `;
                }
            },
            { "data": "orderStatus.statusName", "width": "5%" },
            {
                "data": "id",
                "render": function (id) {
                    return `
                        <div class=" w-75 btn-group" role="group">
                            <a href="/Orders/Delete?orderId=${id}" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-square">Delete</i>
                            </a>
                            
                        </div>
                    `;
                }
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        datatables.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}