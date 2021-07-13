$(document).ready(function () {
    $('#table_id').dataTable({
        "order": [[1, "asc"]]
    });

    $(function () {

     $("#flexCheckChecked").on('change', function () {

            if ($(this).is(':checked')) {
                location.href = "https://localhost:5001/Articulo/ArticulosNoEliminados";
            }
            else {
                location.reload();
            }

        });

    });
});