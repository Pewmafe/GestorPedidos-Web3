$(document).ready(function () {
    $('#articulo_table_id').dataTable({
        "order": [[1, "asc"]]
    });

    $(function () {

        $("#flexCheckChecked").on('change', function () {

            if ($(this).is(':checked')) {
                location.href = "https://localhost:44322/Articulo/ArticulosNoEliminados";
            }
            else {
                location.reload();
            }

        });

    });

    /*$('.botonBorrar').click(function () {
        var miElementoId = $(this).data('id');
        $(".modal-footer #IdArticulo").val(miElementoId);
    });*/


});