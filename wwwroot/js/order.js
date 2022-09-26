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
        paging: true,
        select: true,
        "ajax": {
            "url": `/Orders/GetAllOrders`
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
                "width": "5%",
                "render": function (id) {
                    return `
                        <div class="btn-group">
                            <a href="/Orders/Edit?orderId=${id}" class="btn btn-primary w-50 mx-2 text-center">
                                Edit
                            </a>   
                        </div>
                    `;
                }
            },
            {
                "data": null,
                "render": function () {
                    
                    return `
                                <a class="btn btn-primary" id="status">الحالة</a>
                            `;
                }
            },
            {
                "data": "id",
                "width": "5%",
                "render": function (id) {
                    return `
                        <div class="btn-group">
                            <a href="/Orders/Delete?orderId=${id}" class="btn btn-danger w-50 mx-2 text-center">
                                Delete
                            </a>
                            
                        </div>
                    `;
                }
            }
        ]
    });
}

var statusBtn = document.getElementById("status");
statusBtn.onclick = function () {
    Swal.fire(
        'Good job!',
        'You clicked the button!',
        'success'
    )
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