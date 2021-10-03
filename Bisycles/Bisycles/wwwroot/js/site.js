
$('#bicycle-list').load('/Home/BicycleList')

function start() {

    function wait() {
        console.log($('.countsOfSpecifications').attr('value'))

        specifications()
        categorySort()
        
    }

    setTimeout(wait, 100)
}

function specifications() {
    for (let i = 0; i < $('.countsOfSpecifications').attr('value'); i++) {
        $('.' + i).on('change', function () {

            const currentValue = $('.' + i).val()
            const currentSpecification = $('.' + i).attr('name')

            console.log(currentValue)
            console.log(currentSpecification)

            $('#bicycle-list')
                .load(`/Home/BicycleList/?filterCategory=${currentSpecification}&subcategory=${currentValue}&first=false&check=${$('.' + i).is(':checked')}`)

            start()
        })
    }

    paginations()
}

function paginations() {

    $(`.previousPage`).on('click', function () {

        let newPage = $('.currentPaginationPage').attr('value') - 1

        $('#bicycle-list')
            .load(`/Home/BicycleList/?page=${newPage}&first=false&onlyPage=true`)

        start()
    })

    $(`.nextPage`).on('click', function () {

        let newPage = $('.currentPaginationPage').attr('value') - -1
        console.log(newPage)
        $('#bicycle-list')
            .load(`/Home/BicycleList/?page=${newPage}&first=false&onlyPage=true`)

        start()
    })

    for (let i = 1; i <= $('.pagins').length; i++) {
        $(`.pagins-${i}`).on('click', function () {
            console.log("sdfaf")

            $('#bicycle-list')
                .load(`/Home/BicycleList/?page=${i}&first=false&onlyPage=true`)

            start()
        })
    }
}

function categorySort() {

    for (let i = 1; i <= 8; i++) {
        $(`.thCategory${i}`).on('click', function () {

            if ($(`.thCategory${i}`).hasClass('sort1')) {
                $(`.thCategory${i}`).addClass('sort2')
                $(`.thCategory${i}`).removeClass('sort1')

                console.log($(`.thCategory${i}`).attr('name'))
                console.log("true")

                $('#bicycle-list')
                    .load(`/Home/BicycleList/?first=false&category=${$(`.thCategory${i}`).attr('name')}`)

                $('.sortCategory').off()


                start()
            }
            else {
                $(`.thCategory${i}`).addClass('sort1')
                $(`.thCategory${i}`).removeClass('sort2')

                console.log($(`.thCategory${i}`).attr('name'))
                console.log("false")

                $('#bicycle-list')
                    .load(`/Home/BicycleList/?first=false&category=${$(`.thCategory${i}`).attr('name')}`)

                $('.sortCategory').off()

                start()
            }
        })

        $(`.thCategory${i}`).mouseenter(function () {
            $(`.thCategory${i}`).addClass("text-success")
            console.log("+++")
        })

        $(`.thCategory${i}`).mouseleave(function () {
            $(`.thCategory${i}`).removeClass("text-success")
            console.log("---")
        })
        
        $(`.thBackground${i}`).mouseenter(function () {
            $(`.thBackground${i}`).addClass("bg-secondary")
            console.log("+++")
        })

        $(`.thBackground${i}`).mouseleave(function () {
            $(`.thBackground${i}`).removeClass("bg-secondary")
            console.log("---")
        })
    }
}

function search() {
    $('.search').keyup(function () {
        let xxx = $('.search').val()
        
        if ($('.search').val() == "") {
            xxx = "null"
        }
        console.log(xxx)
        $('#bicycle-list')
            .load(`/Home/BicycleList/?first=false&search=${xxx}`)

        start()
    })

    //$('.search').change(function () {
    //    let xxx = $('.search').val()
    //    console.log(xxx)


    //    $('#bicycle-list')
    //        .load(`/Home/BicycleList/?first=false&search=${$('.search').val()}`)

    //    start()
    //})
}

setTimeout(start, 100)
setTimeout(search, 100)



