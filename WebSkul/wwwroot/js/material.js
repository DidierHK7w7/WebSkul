//validacion para eliminar
function confirmacion(e) {
    if (confirm("Esta seguro de eliminar este elemento?")) {
        return true;
    } else {
        e.preventDefault();
    }
}
let linkdelete = document.querySelectorAll(".table__item__link");
for (var i = 0; i < linkdelete.length; i++) {
    linkdelete[i].addEventListener('click', confirmacion);
}

//sidenav
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.sidenav');
    var instances = M.Sidenav.init(elems);
});

//select form
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems);
});