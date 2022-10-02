

function Delete(id) {
    Swal.fire({
        title: 'Are you sure',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/Orders/Delete/${id}`,
                type: "DELETE",
                success: function () {
                    window.location.reload();
                }
            })
        }
    })
}

var orderStatusId;
function SaveOrderStatus(currentElement, orderId) {
    orderStatusId = currentElement.value;
    $.ajax({
        url: `/Orders/SaveOrderStatus?orderStatusId=${orderStatusId}&orderId=${orderId}`,
        type: "GET",
        success: function () {
            window.location.reload();
        }
    })
}