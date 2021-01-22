
var selectedRow = null

function onFormSubmit() {
   if (validate()) {
        var FormData = readFormData();
        if (selectedRow == null) {
            insertNewRecord(FormData)
        }
        else
           updateRecord(FormData);

        resetForm();
    }
}
function readFormData() {

    var formData = {};
    formData["Name"] = document.getElementById("Name").value;
    formData["Email"] = document.getElementById("Email").value;
    formData["Phone"] = document.getElementById("Phone").value;
    return formData;
}

function insertNewRecord(data) {

    var table = document.getElementById("employeeList").getElementsByTagName('tbody')[0];
    var newRow = table.insertRow(table.lenght);
    cell1 = newRow.insertCell(0);
    cell1.innerHTML = data.Name;
    cell2 = newRow.insertCell(1);
    cell2.innerHTML = data.Email;
    cell3 = newRow.insertCell(2);
    cell3.innerHTML = data.Phone;
    cell4 = newRow.insertCell(3);
    cell4.innerHTML = "<button type='button'>update</button>";

    var rowsCount = table.rows.length + 1;
    newRow.id = 'row' + rowsCount;

    cell4.innerHTML += `<button type="button" onClick="onDelete('row${rowsCount}')">delete</button>`;

}

function resetForm() {
    document.getElementById("Name").value = "";
    document.getElementById("Email").value = "";
    document.getElementById("Phone").value = "";
    selectedRow = null;
   
}

function onEdit(button) {
    td = button.parentElement
    selectedRow = td.parentElement;
    document.getElementById("Name").value = selectedRow.cells[0].innerHTML;
    document.getElementById("Email").value = selectedRow.cells[1].innerHTML;
    document.getElementById("Phone").value = selectedRow.cells[2].innerHTML;
}

function updateRecord(formData) {
    selectedRow.cells[0].innerHTML = formData.Name;
    selectedRow.cells[1].innerHTML = formData.Email;
    selectedRow.cells[2].innerHTML = formData.Phone;
}



function onDelete(rowId) {
    if (confirm('Are you sure you want to delete this record ? ')) {
        var row = document.getElementById(rowId);

        //var row = td.parentElement.parentElement;
        document.getElementById("employeeList").deleteRow(row.rowIndex);
        resetForm();
    }

}

function validate() {
    isvalid = true
    if (document.getElementById("Name").value == "") {

        isvalid = false;
        document.getElementById("NameValidationError").classList.remove("hide")
    }
    else {
        isvalid = true;
        if (!document.getElementById("NameValidationError").classList.contains("hide"))
            document.getElementById("NameValidationError").classList.add("hide");
    }
    return isvalid;

    }
