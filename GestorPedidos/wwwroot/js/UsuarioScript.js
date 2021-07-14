$(document).ready(function () {
    $('#table_id').dataTable({
        "order": [[1, "asc"]]
    });

    $(function () {

        $("#flexCheckChecked").on('change', function () {

            if (!$(this).is(':checked')) {


                LoadDataUsers();
            }

            else {

                location.reload();
            }

        });

    });



    function LoadDataUsers() {
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
                "pageLength": 10,

                "ajax": {
                    "url": "TodosLosUsuarios",
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
                        "title": "Eliminados", "render": function (data, type, full, meta) {

                            if (full.fechaBorrado == 1) {
                                return '<i class="text-center fst-italic"><p>Eliminado</p></i>';
                            }
                            
                            return  '<div>' +
                                        '<button type="button" class="btn botonBorrar" data-bs-toggle="modal" data-bs-target="#borrarUsuario-' + full.idUsuario + '" data-id=' + full.idUsuario + '">' +
                                            '<i class="fas fa-times btn text-danger"></i>' +
                                        '</button>'+
                                '<div class="modal fade" id="borrarUsuario-' + full.idUsuario + '" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">'+
                                '<div class="modal-dialog">' +
                                '<div class="modal-content">' +
                                '<div class="modal-header">' +
                                '<h5 class="modal-title" id="exampleModalLabel">Eliminar usuario</h5>' +
                                '<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>' +
                                '</div>' +
                                '<div class="modal-body">' +
                                '<p>¿Esta seguro que desea eliminar este usuario? ' + full.nombre + '</p>' +
                                '</div>' +
                                '<div class="modal-footer">' +
                                '<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>' +
                                '<form action="/Usuario/BajaUsuario" method="post">' +
                                '<input type="hidden" id="id" name="id" value="' + full.idUsuario + '" />' +
                                '<button type="submit" class="btn btn-danger">Eliminar</button>' +
                                '</form>' +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                    '</div >';
                        }

                            
                    },

                ]

            });
        });

    }

    /*$('.botonBorrar').click(function () {
        var miElementoId = $(this).data('id');
        $(".modal-footer #IdUsuario").val(miElementoId);
    });*/

});

