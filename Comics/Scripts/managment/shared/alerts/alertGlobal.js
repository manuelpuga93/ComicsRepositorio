TiposAlerta = {
    EXITO: { modal: "modal-header modal-header-success", btn: "btn btn-success" },
    INFO: { modal: "modal-header modal-header-info", btn: "btn btn-info" },
    ADVERTENCIA: { modal: "modal-header modal-header-warning", btn: "btn btn-warning" },
    ERROR: { modal: "modal-header modal-header-danger", btn: "btn btn-danger" },
    DEFAULT: { modal: "modal-header modal-header-primary", btn: "btn btn-primary" }
}

function mostrarAlerta(titulo, mensaje, tipoAlerta) {
    var lastClass = $('#modalHeader').attr('class').split(' ').pop();
    $('#modalHeader').removeClass(lastClass);

    lastClass = $('#btnOk').attr('class').split(' ').pop();
    $('#btnOk').removeClass();

    $('#modalHeader').addClass('modal-header ' + tipoAlerta.modal);
    $('#btnOk').addClass('btn ' + tipoAlerta.btn);
    $('#modalTitle').empty().append(titulo);
    $('#modalText').empty().append(mensaje);
    $('#alertModal').modal('show');
}