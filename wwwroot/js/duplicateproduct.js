let row = document.getElementById("productRow");
let dup_btn = document.getElementById("duplicate");
let tbody = document.getElementById("tbody");
let removeRowBtn = document.getElementsByClassName("removeRow").item(0);

dup_btn.onclick = function () {
    let dup_row = row.cloneNode(true);
    tbody.appendChild(dup_row);
    let removeRowBtn = document.getElementsByClassName("removeRow");
    removeRowBtn = [...removeRowBtn];

   

    for (let currentBtn of removeRowBtn) {
        currentBtn.addEventListener('click', function () {
            currentBtn.parentNode.parentNode.remove();
        })
    }
}

removeRowBtn.addEventListener('click', function () {
    removeRowBtn.parentNode.parentNode.remove();
})

