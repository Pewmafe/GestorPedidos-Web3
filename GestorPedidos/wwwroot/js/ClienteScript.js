$(document).ready(function () {
    $('#table_id').dataTable({
    });

    $(function () {

        $("#flexCheckChecked").on('change', function () {

            if ($(this).is(':checked')) {
                LoadDataClienteNotDeleted();
            }

            else {
                location.reload();
            }

        });

    });

    function LoadDataClienteNotDeleted() {
        $(document).ready(function () {

            $('#table_id').dataTable({
                "bDestroy": true
            }).fnDestroy();

            $('#table_id thead tr').remove()

            $("#table_id").DataTable({


                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "pageLength": 5,

                "ajax": {
                    "url": "ClientesNoEliminados",
                    "type": "POST",
                    "datatype": "json"
                },



                "columns": [
                    { "data": "idCliente", "title": "#", "name": "idCliente", "autoWidth": true },
                    { "data": "nombre", "title": "Nombre", "name": "nombre", "autoWidth": true, },
                    { "data": "numero", "title": "Numero", "name": "numero", "autoWidth": true, },
                    { "data": "email", "title": "Email", "name": "email", "autoWidth": true },
                    { "data": "telefono", "title": "Telefono", "name": "telefono", "autoWidth": true },
                    { "data": "direccion", "title": "Direccion", "name": "direccion", "autoWidth": true, },
                    { "data": "cuit", "title": "CUIT", "name": "cuit", "autoWidth": true },


                    {
                        "title": "Ver", "render": function (data, type, full, meta) { return '<a href="/cliente/Editarcliente?idCliente=' + full.idCliente + ' data-bs-toggle="tooltip" data-placement="top" title="Ver Cliente"><i class="fas fa-info btn"></i></a>'; }
                    },
                    {
                        "title": "Eliminar", "render": function (data, type, full, meta) { return '<a href="/cliente/Borrarcliente?idCliente=' + full.idCliente + ' data-bs-toggle="tooltip" data-bs-placement="top" title="Eliminar Cliente"> <i class="fas fa-times btn text-danger"></i></a>'; }
                    },

                ]

            });
        });

    }
});