//Variable


function loadSumValue() {
    $('#game-sum-value').text($('#game-sum-value').attr("data-sum"));
    //$('#game-sum-value').append($('#game-sum-value').attr("data-sum"));
    changeInpiutText();
    addAllWithSum();
    clearAllValueWithSum();
    timer();
    checkTimer();
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

function timer() {
    $(function () {
        $('.svg-timer').svgTimer();

    });
}

function checkTimer() {
    window.setInterval(function () {
        var value = $(".svg-hexagonal-counter h2");
        if (value.text() == 60) {
            console.log('poszlo');
        }

    }, 500);
}

//Fancy Box
