$(document).ready(function () {
    $('#table_id').dataTable({
        "order": [[1, "asc"]]
    });

    $(function () {

        $("#flexCheckChecked").on('change', function () {

            if ($(this).is(':checked')) {
                location.href = "https://localhost:44322/Cliente/ClientesNoEliminados";
            }
            else {
                location.reload();
            }

        });

    });

   
});