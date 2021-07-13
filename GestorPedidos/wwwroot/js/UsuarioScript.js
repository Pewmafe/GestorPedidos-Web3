$(document).ready(function () {

});

$(function () {

    $("#flexCheckChecked").on('change', function () {

        if ($(this).is(':checked')) {


            LoadDataUsersNotDeleted();
        }

        else {

            location.reload();
        }

    });

});

function LoadDataUsersNotDeleted() {
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
                "url": "UsuariosNoEliminados",
                "type": "POST",
                "datatype": "json"
            },



            "columns": [
                { "data": "idUsuario", "title": "#", "name": "idUsuario", "autoWidth": true },
                { "data": "nombre", "title": "Nombre", "name": "nombre", "autoWidth": true, },
                { "data": "email", "title": "Email", "name": "email", "autoWidth": true },
                { "data": "fechaNacimiento", "title": "Fecha Nacimiento", "name": "fechaNacimiento", "autoWidth": true },


                {
                    "title": "Ver", "render": function (data, type, full, meta) { return '<a href="EditarUsuario/' + full.idUsuario + '" data-bs-toggle="tooltip" data-bs-placement="top" title="Ver Usuario"><i class="fas fa-info btn"></i></a>'; }
                },
                {
                    "title": "Eliminados", "render": function (data, type, full, meta) { return '<a href="BajaUsuario/' + full.idUsuario + '" data-bs-toggle="tooltip" data-bs-placement="top" title="Eliminar Usuario"><i class="fas fa-times btn text-danger"></i></a>'; }
                },

            ]

        });
    });

}


