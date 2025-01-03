window.showToastr = function (type, message) {
    if (type === 'error') {
        toastr.error(message);
    } else if (type === 'success') {
        toastr.success(message);
    }
}

window.showSweetAlert = function (type, message) {
    if (type === 'error') {
        Swal.fire({
            title: "Oops...",
            text: message,
            icon: "error"
        });
    } else if (type === 'success') {
        Swal.fire({
            title: "Good job!",
            text: message,
            icon: "success"
        });
    }
}