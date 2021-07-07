$(document).ready(function () {
    $('#articulos-select').select2();
    $('#articulos-select2').select2();
    $('#articulos-select3').select2();


    $(function () {
        $("#agregarAlCarrito").on().click(function () {
            AgregarAlCarrito();
        });

    });
    $(function removerDelCarrito() {
        $("#removerDelCarrito").on().click(function removerDelCarrito() {
            RemoverDelCarrito();
        });
    });
 
    function AgregarAlCarrito() {
        console.log("entramos a loadData")
        var idArticulo = parseInt($("#articulos-select").val());
        console.log(idArticulo);
        $("#tblCarrito tbody tr td").remove();
        $.ajax({
            type: 'GET',
            url: 'AgregarArticuloAlCarrito',
            dataType: 'json',
            data: { idArticulo: idArticulo },
            success: function (data) {
                var items = '';
                $.each(data, function (i, articulo) {
                    console.log(articulo)
                    var rows = "<tr>"
                        + "<td class='text-center'>" + articulo.descripcion + "</td>"
                        + "<td class='text-center'>" + articulo.codigo + "</td>"
                        + "<td class='text-center'>"
                        + "<span data-bs-toggle='tooltip' data-placement='top' title='Ver articulo'><i class='fas fa-info btn'></i></span> |"
                        + "<span data-bs-toggle='tooltip' data-placement='top' title = 'Eliminar del carrito' > <i class='fas fa-times btn text-danger'></i></span >"
                        + "</td >"
                        + "</tr>";
                    $('#tblCarrito tbody').append(rows);
                });

            },
            error: function (ex) {
                alert("Message: error ");
            }
        });
        return false;
    }
    function RemoverDelCarrito() {
        console.log("entramos a RemoverDelCarrito")
        var idPedido = parseInt($("#idPedido").val());
        var idArticulo = parseInt($("#idArticulo").val());
        console.log(idArticulo);
        console.log(idPedido);
        $("#tblCarritoEditar tbody tr td").remove();
        $.ajax({
            type: 'GET',
            url: 'AgregarArticuloAlCarrito',
            dataType: 'json',
            data: { idArticulo: idArticulo, idPedido: idPedido },
            success: function (data) {
                var items = '';
                console.log(data);
                $.each(data, function (i, articulo) {
                    console.log(i + "*******" + JSON(articulo) );
                    var rows = "<tr>"
                        + "<td class='text-center'>" + articulo.pedido.descripcion + "</td>"
                        + "<td class='text-center'>" + articulo.articulo.codigo + "</td>"
                        + "<td class='text-center'>" + + "</td>"
                        + "<td class='text-center'>"
                        + "<span data-bs-toggle='tooltip' data-placement='top' title='Ver articulo'><i class='fas fa-info btn'></i></span> |"
                        + "<span data-bs-toggle='tooltip' data-placement='top' title = 'Eliminar del carrito' > <i class='fas fa-times btn text-danger'></i></span >"
                        + "</td >"
                        + "</tr>";
                    $('#tblCarritoEditar tbody').append(rows);
                });

            },
            error: function (ex) {
                alert("Message: error ");
            }
        });
        return false;
    }

});
