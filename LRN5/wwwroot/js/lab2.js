const uri = 'api/Languages';
let languages = [];

function getLanguages() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayLanguages(data))
        .catch(error => console.error('Unable to get languages.', error));
}

function addLanguage() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');

    const language = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(language)
    })
        .then(response => response.json())
        .then(() => {
            getLanguages();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add language.', error));
}

function deleteLanguage(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getLanguages())
        .catch(error => console.error('Unable to delete language.', error));
}

function displayEditForm(id) {
    const language = languages.find(language => language.id === id);

    document.getElementById('edit-id').value = language.id;
    document.getElementById('edit-name').value = language.name;
    document.getElementById('edit-info').value = language.info;
    document.getElementById('editForm').style.display = 'block';
}

function updateLanguage() {
    const languageId = document.getElementById('edit-id').value;
    const language = {
        id: parseInt(languageId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${languageId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(language)
    })
        .then(() => getLanguages())
        .catch(error => console.error('Unable to update language.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayLanguages(data) {
    const tBody = document.getElementById('languages');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(language => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${language.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteLanguage(${language.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(language.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(language.info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    languages = data;
}
