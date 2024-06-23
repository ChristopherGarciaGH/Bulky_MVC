$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            "ajax": {url:'/admin/producto/getall'},
            "columns": [
            { data: 'titulo', "width": "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listaPrecios', "width": "10%" },
            { data: 'autor', "width": "20%" },
            { data: 'categoria.nombre', "width": "15%" }
            ]
    });
}
