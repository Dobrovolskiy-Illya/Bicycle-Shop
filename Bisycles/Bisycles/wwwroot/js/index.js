var tokenKey = "access_token"

async function getBicycles() {
    const token = sessionStorage.getItem(tokenKey)
    const response = await fetch('/api/bicycles', {
        method: 'GET',
        headers: {
            'Authorization': 'bearer ' + token
        }
    })
    if (response.ok === true) {
        const bicycles = await response.json()
        let rows = document.querySelector('tbody')
        bicycles.forEach(bicycyle => rows.append(createTableRow(bicycyle)))
    }
}



function showError(errors) {
    errors.forEach(error => {
        const p = document.createElement('p')
        p.append(error)
        document.getElementById('errors').append(p)
    })
} 

async function getTokenAsync() {
    const credentials = {
        login: document.getElementById('login').value,
        password: document.getElementById('password').value
    }

    const response = await fetch('api/account/token', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    })

    const data = await response.json()
    if (response.ok === true) {
        sessionStorage.setItem(tokenKey, data.access_token)
        getCars()
    } else {
        console.log(response.status, response.errorText)
    }
}


document.getElementById('loginForm').addEventListener('click', function () {
    getTokenAsync()
})






























let j = 0;

function createTableRow(bicycyle) {
    const tr = document.createElement('tr')
    tr.className = `trClass${j}`


    const bicycleTitleTd = document.createElement('td')
    bicycleTitleTd.className = `tdClass${j}`
    bicycleTitleTd.append(bicycyle.bicycleTitle)
    tr.append(bicycleTitleTd)  

    const bicycleFrameSizeTd = document.createElement('td')
    bicycleFrameSizeTd.className = `tdClass${j}`
    bicycleFrameSizeTd.append(bicycyle.bicycleFrameSize)
    tr.append(bicycleFrameSizeTd)

    const bicycleWheelDiameterTd = document.createElement('td')
    bicycleWheelDiameterTd.className = `tdClass${j}`
    bicycleWheelDiameterTd.append(bicycyle.bicycleWheelDiameter)
    tr.append(bicycleWheelDiameterTd)

    const bicycleColorTd = document.createElement('td')
    bicycleColorTd.className = `tdClass${j}`
    bicycleColorTd.append(bicycyle.bicycleColor)
    tr.append(bicycleColorTd)

    const bicycleNumberOfSpeedsTd = document.createElement('td')
    bicycleNumberOfSpeedsTd.className = `tdClass${j}`
    bicycleNumberOfSpeedsTd.append(bicycyle.bicycleNumberOfSpeeds)
    tr.append(bicycleNumberOfSpeedsTd)

    const bicycleManufactureCountryTd = document.createElement('td')
    bicycleManufactureCountryTd.className = `tdClass${j}`
    bicycleManufactureCountryTd.append(bicycyle.bicycleManufactureCountry)
    tr.append(bicycleManufactureCountryTd)

    const bicucleWeightTd = document.createElement('td')
    bicucleWeightTd.className = `tdClass${j}`
    bicucleWeightTd.append(bicycyle.bicucleWeight)
    tr.append(bicucleWeightTd)

    const bicyclePriceTd = document.createElement('td')
    bicyclePriceTd.className = `tdClass${j}`
    bicyclePriceTd.append(bicycyle.bicyclePrice)
    tr.append(bicyclePriceTd)

    const bicycleEditTd = document.createElement('td')
    bicycleEditTd.className = `tdClass${j}`
    bicycleEditTd.innerHTML = `<button class="edit" id="trId${j}">Edit</button>`
    tr.append(bicycleEditTd)

    const bicycleDeleteTd = document.createElement('td')
    bicycleDeleteTd.id = `${bicycyle.bicycleId}`
    bicycleDeleteTd.className = `ShowItemId${j}`
    bicycleDeleteTd.innerHTML = `<button class="delete tdClass${j}" id="${j}">Delete</button>`
    tr.append(bicycleDeleteTd)

    j++

    return tr
}





async function getBicycles() {
    const response = await fetch('/api/bicycle')
    if (response.ok === true) {
        const bicycles = await response.json()
        let rows = document.querySelector('tbody')
        bicycles.forEach(bicycyle => rows.append(createTableRow(bicycyle)))


        /////////////////////////
        //console.log($('tr').length)

        //const asdf = document.getElementById(`trId${j}`)
        //console.log(asdf.innerText)
        for (let i = 0; i < $('.edit').length; i++) {
            $(`#trId${i}`).click(function () {
                console.log("start")

                console.log($(`.tdClass${i}`).length)

                for (let j = 0; j < $(`.tdClass${i}`).length - 2; j++) {
                    let test = $(`.tdClass${i}`)[j]
                    let x = test.innerText
                    test.innerHTML = `<input type="text" id="tr${i}td${j}" value="${x}">`
                }


                let test = $(`.tdClass${i}`)[$(`.tdClass${i}`).length - 2]
                test.innerHTML = null;
                test.innerHTML = `<button class="edit" id="SaveId${i}">Save</button>`


                $(`#SaveId${i}`).on('click', function () {
                    editBicycle(
                        $(`.ShowItemId${i}`).attr('id'),
                        $(`#tr${i}td${0}`).val(),
                        $(`#tr${i}td${1}`).val(),
                        $(`#tr${i}td${2}`).val(),
                        $(`#tr${i}td${3}`).val(),
                        $(`#tr${i}td${4}`).val(),
                        $(`#tr${i}td${5}`).val(),
                        $(`#tr${i}td${6}`).val(),
                        $(`#tr${i}td${7}`).val()
                    )
                })
            })
        }

        


        for (let i = 0; i < $('.delete').length; i++) {
            $(`#${i}`).click(function () {

                let Id = $(`.ShowItemId${i}`).attr('id')

                fetch('/api/bicycle/' + Id, {
                    method: 'DELETE'
                })
                    .then(res => res.json())

                $(`.trClass${i}`).remove()
                
            })
        }
        console.log(bicycles)
    }
}


async function editBicycle(bicycleId, bicycleTitle, bicycleFrameSize, bicycleWheelDiameter, bicycleColor, bicycleNumberOfSpeeds, bicycleManufactureCountry, bicucleWeight, bicyclePrice) {
    const response = await fetch('/api/bicycle', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify({
            bicycleId: +bicycleId,
            bicycleTitle,
            bicycleFrameSize: +bicycleFrameSize,
            bicycleWheelDiameter: +bicycleWheelDiameter,
            bicycleColor,
            bicycleNumberOfSpeeds: +bicycleNumberOfSpeeds,
            bicycleManufactureCountry,
            bicucleWeight: +bicucleWeight,
            bicyclePrice: +bicyclePrice
        })
    })

    if (response.ok === true) {
        document.querySelector('tbody').innerHTML = null
        getBicycles()
    }
}




async function createBicycle(bicycleTitle, bicycleFrameSize, bicycleWheelDiameter, bicycleColor, bicycleNumberOfSpeeds, bicycleManufactureCountry, bicucleWeight, bicyclePrice) {
    const response = await fetch('/api/bicycle', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',   
            'Accept': 'application/json'
        },
        body: JSON.stringify({
            bicycleTitle,
            bicycleFrameSize: +bicycleFrameSize,
            bicycleWheelDiameter: +bicycleWheelDiameter,
            bicycleColor,
            bicycleNumberOfSpeeds: +bicycleNumberOfSpeeds,
            bicycleManufactureCountry,
            bicucleWeight: +bicucleWeight,
            bicyclePrice: +bicyclePrice
        })
    })

    if (response.ok === true) {
        const bicycle = await response.json()
        document.querySelector('tbody').append(createTableRow(bicycle))
    }
}




document.forms['bicycleForm'].addEventListener('submit', function (e) {
    e.preventDefault()
    const form = document.forms['bicycleForm']
    const bicycleTitle = form.elements['bicycleTitle'].value
    const bicycleFrameSize = form.elements['bicycleFrameSize'].value
    const bicycleWheelDiameter = form.elements['bicycleWheelDiameter'].value
    const bicycleColor = form.elements['bicycleColor'].value
    const bicycleNumberOfSpeeds = form.elements['bicycleNumberOfSpeeds'].value
    const bicycleManufactureCountry = form.elements['bicycleManufactureCountry'].value
    const bicucleWeight = form.elements['bicucleWeight'].value
    const bicyclePrice = form.elements['bicyclePrice'].value

    createBicycle(bicycleTitle, bicycleFrameSize, bicycleWheelDiameter, bicycleColor, bicycleNumberOfSpeeds, bicycleManufactureCountry, bicucleWeight, bicyclePrice)
})

getBicycles()



