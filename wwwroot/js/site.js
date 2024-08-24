// Modificado de https://getbootstrap.com/docs/5.3/forms/validation/
function configurarValidacionFormsBoostrap() {
  const forms = document.querySelectorAll('.needs-validation');

  Array.from(forms).forEach(form => {
    form.addEventListener("submit", event => {
      if (!form.checkValidity()) {
        event.preventDefault();
        event.stopPropagation();
      }

      form.classList.add("was-validated");
    });
  });
}

configurarValidacionFormsBoostrap();