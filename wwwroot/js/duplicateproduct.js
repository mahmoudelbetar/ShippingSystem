let row = document.getElementById("productRow");
let dup_btn = document.getElementById("duplicate");
let tbody = document.getElementById("tbody");
let removeRow = document.getElementById("removeRow");

dup_btn.onclick = function () {
    let dup_row = row.cloneNode(true);
    tbody.appendChild(dup_row);
}