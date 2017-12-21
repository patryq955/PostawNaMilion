//Variable


function loadSumValue() {
    $('#game-sum-value').text($('#game-sum-value').attr("data-sum"));
    //$('#game-sum-value').append($('#game-sum-value').attr("data-sum"));
    changeInpiutText();
    addAllWithSum();
    clearAllValueWithSum();
    plusValueWithSum();
    minusValueWithSum();
    timer();
}

function addAllWithSum() {
    $(document).delegate('#input_all', 'click', function (e) {

        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        $("#input-" + idAnswer).val(parseInt($('#game-sum-value').text()) + parseInt($("#input-" + idAnswer).val()));
        $('#game-sum-value').text('0');
        return false;
    });
}

function changeInpiutText() {
    $(document).delegate('#input_container input', 'focusout', function (e) {
        e.preventDefault();
        valueToAdd = Math.ceil($(this).val() / 25000) * 25000;
        if (valueToAdd <= $('#game-sum-value').text()) {
            $('#game-sum-value').text(parseInt($('#game-sum-value').text()) - parseInt(valueToAdd));
            $(this).val(valueToAdd);
            return;
        }


        $(this).val($('#game-sum-value').text());
        $('#game-sum-value').text(0);


    })

    $("#input_container input").bind('keyup mouseup', function () {
        if ($(this).val() > $('#game-sum-value'))
        { }

    });
}

function clearAllValueWithSum() {

    $(document).delegate('#input_clear', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) + parseInt(+$("#input-" + idAnswer).val()));
        $("#input-" + idAnswer).val('0');
        return false;
    });
}

function plusValueWithSum() {

    $(document).delegate('#input_plus', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        if (parseInt($('#game-sum-value').text()) <= 0) {
            return;
        }
        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) - 25000);
        $("#input-" + idAnswer).val(25000 + parseInt(+$("#input-" + idAnswer).val()));
        console.log('klik plus');
        return false;
    });
}

function minusValueWithSum() {

    $(document).delegate('#input_minus', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        if (parseInt($('#game-sum-value').text()) >= 1000000)
        {
            return;
        }

        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) + 25000);
        $("#input-" + idAnswer).val(parseInt(+$("#input-" + idAnswer).val()) - 25000);
        console.log('klik plus');
        return false;
    });
}

function timer() {
    $(function () {
        $('.svg-timer').svgTimer();

    });
}



//Fancy Box
