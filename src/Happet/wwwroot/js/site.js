$(document).ready(function () {
    $('#typePerson').modal({ backdrop: 'static', keyboard: false });
    $('#deletePets').modal({ backdrop: 'static', keyboard: false });
    $('#AdoptionTerm').modal({ backdrop: 'static', keyboard: false });

    OnlyNumbers('#RG');
    OnlyNumbers('#CPF');
    OnlyNumbers('#CNPJ');
    OnlyNumbers('#CellPhone');
    OnlyNumbers('#CEP');
});

function OnlyNumbers(id) {
    $(id).on('input', function (event) {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
}