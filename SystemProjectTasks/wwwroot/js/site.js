// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let tdDescription = document.getElementsByClassName("description");
const tablaProyectos = document.getElementById("tabla-proyectos");
const tablaCrearProyectos = document.getElementById("formulario-creacion");
let botonCrear = false;

for (const iterator of tdDescription) {
  iterator.setAttribute("title", iterator.innerText);
}

const boton = document.getElementById("boton");
boton.addEventListener("click", () => {
  tablaProyectos.classList.toggle("oculto");
  tablaCrearProyectos.classList.toggle("oculto");
  botonCrear = !botonCrear;
  if (botonCrear) {
    boton.innerText = "Mostrar Proyectos";
  } else {
    boton.innerText = "Crear Proyecto";
  }
});
