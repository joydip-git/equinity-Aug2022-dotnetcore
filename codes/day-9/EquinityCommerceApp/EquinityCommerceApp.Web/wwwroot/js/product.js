var dataTbl;
$(document).ready(function () {
    loadDataTable()
})

function loadDataTable() {
    dataTbl = $('#tblProducts').DataTable({
        "ajax": {
            "url":"/Products/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "listPrice", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                            <a class="btn btn-primary mx-2" href="/Products/Upsert?id=${data}">
                                <i class="bi bi-pencil-square"></i>&nbsp;&nbsp;Edit
                            </a>
                            <a class="btn btn-danger mx-2" href="/Products/Delete/${data}">
                                <i class="bi bi-trash-fill"></i>&nbsp;&nbsp;Delete
                            </a>
                        </div>
                    `
                }
            }
        ]
    })
}