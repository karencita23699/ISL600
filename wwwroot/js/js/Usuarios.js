$.get("/Home/ListarUsuario", function (data) {
    console.log(data);
    crearListado(data);
});
function crearListado(data) {
    var contenido = "";
    contenido += "<div class='table - responsive'>"
    contenido += "<table class='table table-dark table-sm'>";
    contenido += "<thead>";
    contenido += "<tr class=''text-center roboto-medium'>";
    contenido += "<th>#</th>";
    contenido += "<th>NOMBRE DE USUARIO</th>";
    contenido += "<th>PASSWORD</th>";
    contenido += "<th>TIPO</th>";
    contenido += "<th>MODIFICAR</th>";
    contenido += "<th>ELIMINAR</th>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    
    for (var i = 0; i < data.length; i++) {
        contenido += "<tr class='text - center'>";
        contenido += "<td>" + data[i].ID + "</td>";
        contenido += "<td>" + data[i].NOMUSUARIO + "</td>";
        contenido += "<td>" + data[i].PASSWD + "</td>";
        contenido += "<td>" + data[i].TIPO + "</td>";
        contenido += "<td><a href = '#' class='btn btn-success' ><i class='fas fa-sync-alt'></i></a ></td >";
        contenido += " <td><form action=''><button type='button' class='btn btn-warning'><i class='far fa-trash-alt'></i></button></form></td>";
        contenido += "</tr>";
    }

    contenido += "</tbody></table></div>";
    document.getElementById("tablausuarios").innerHTML=contenido;
}