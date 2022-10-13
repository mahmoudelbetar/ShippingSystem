let row = document.getElementById("productRow");
let dup_btn = document.getElementById("duplicate");
let tbody = document.getElementById("tbody");
let removeRowBtn = document.getElementsByClassName("removeRow").item(0);
let totalWeight = document.getElementById("totalWeight");
let weights = document.getElementsByClassName("weights");
let save = document.getElementById("save");
weights = [...weights];
var count = 0;

totalWeight.value = "";

var totweight = parseFloat(totalWeight).toFixed(2);
totweight = 0;






dup_btn.onclick = function () {
    
    let dup_row = row.cloneNode(true);
    tbody.appendChild(dup_row);

    let weights = document.getElementsByClassName("weights");
    weights = [...weights];


    totweight += parseFloat(weights[count].value);
    totalWeight.value = totweight;
    count = count + 1;

    let removeRowBtn = document.getElementsByClassName("removeRow");
    removeRowBtn = [...removeRowBtn];

   

    for (let currentBtn of removeRowBtn) {
        currentBtn.addEventListener('click', function () {
            currentBtn.parentNode.parentNode.remove();
            let weights = document.getElementsByClassName("weights");
            weights = [...weights];

            count = count - 1;
            totweight -= parseFloat(weights[count].value);
            totalWeight.value = totweight;
           
        })
    }

    
    

}

removeRowBtn.addEventListener('click', function () {
    removeRowBtn.parentNode.parentNode.remove();
})


$("#addPname").click(function () {
    var pname = $("#pname").val();
    var pquantity = $("#pquantity").val();
    var pweight = $("#pweight").val();
    var product = { "pname": pname, "pquantity": pquantity, "pweight": pweight };
    var products = [];
    products.push(product);
    console.log(products);
    $.ajax({
        url: `/Orders/AddProductName`,
        data: products,
        success: function (data) {
            console.log(data);
        }
    })
})
