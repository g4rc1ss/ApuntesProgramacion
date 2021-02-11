function FilterActivityListEventHandler(input, divId) {
    let timeout = null;
    timeout = setTimeout(function () {
        FilterActivityList(input, divId);
    }, 1000);
}

function FilterActivityList(tagToSearch, divId) {

    let filter, firstLevelBox, firstLevel, thirdLevelElementLi, activityLevel, activityTitle, firstLevelElement, secondLevelElement, activityElements;

    filter = tagToSearch.value.toUpperCase();
    firstLevelBox = document.getElementById(divId);
    firstLevel = firstLevelBox.getElementsByTagName('li');

    const filterValue = divId === "avaiableActivities" ? "AvailableActivities" : "SelectedActivities";
    activityElements = document.querySelectorAll(`[id^=${filterValue}]`);


    for (let activityElement of activityElements) {

        activityLevel = activityElement.nextElementSibling.innerText.split(' ').length;
        if (activityLevel === 1 || activityLevel === 2) {
            activityElement.closest('li').style.display = 'none';

        } else if (activityLevel === 3) {

            activityTitle = activityElement.parentElement.innerText;
            if (activityTitle.toUpperCase().includes(filter) || filter === "") {

                thirdLevelElementLi = activityElement.closest('li');
                thirdLevelElementLi.style.display = 'block';
                secondLevelElement = activityElement.closest('ul').closest('li');
                secondLevelElement.style.display = 'block';
                firstLevelElement = secondLevelElement.closest('ul').closest('li');
                firstLevelElement.style.display = 'block';

                if (filter != "") {

                    activityElement.closest('.collapse').classList.add('show');
                    openAccordionByAccordionToggle(secondLevelElement);

                    secondLevelElement.closest('ul').classList.add('show');
                    openAccordionByAccordionToggle(firstLevelElement);

                } else {

                    activityElement.closest('.collapse').classList.remove('show');
                    closeAccordionByAccordionToggle(secondLevelElement);

                    secondLevelElement.closest('ul').classList.remove('show');
                    closeAccordionByAccordionToggle(firstLevelElement);

                }


            } else {

                activityElement.closest('.accordion-secondlevel').style.display = 'none'

            }

        }
    }

}
function closeAccordionByAccordionToggle(element) {
    element.querySelector('.accordion-toggle').classList.remove('collapsed');
    element.querySelector('.accordion-toggle').setAttribute('aria-expanded', 'false');
}
function openAccordionByAccordionToggle(element) {
    element.querySelector('.accordion-toggle').classList.add('collapsed');
    element.querySelector('.accordion-toggle').setAttribute('aria-expanded', 'true');
}

function setAllCheckboxes(divId, sourceCheckbox) {
    $('#' + divId).find(':checkbox').each(function () {
        //if ($(this).is(':visible')) {
        $(this).prop('checked', $(sourceCheckbox).is(':checked'));
        //}
    });
}

function moveItemsToTheRight() {
    var newSelectedActivities = [];
    $.each($("input[name='activityRight']"), function () {
        newSelectedActivities.push($(this).val());
    });
    $.each($("input[name='activityLeft']:checked"), function () {
        newSelectedActivities.push($(this).val());
    });

    if (newSelectedActivities.length > 0) {
        manageActivitiesSide(newSelectedActivities, 1);
    }
}

function moveItemsToTheLeft() {
    var activitiesToMove = [];
    $.each($("input[name='activityRight']:checked"), function () {
        activitiesToMove.push($(this).val());
    });

    if (activitiesToMove.length > 0) {
        manageActivitiesSide(activitiesToMove, -1);
    }
}

function moveChapter(chapterId, currentPosId, dir) {

    console.log("Moving UP " + chapterId);

    // Getting the list elements
    var currentItem = $('#' + 'sel_parent_chapter_' + chapterId);
    var currentLbl = $('#' + 'lbl_chapter_' + chapterId);

    var otherItem
    if (dir < 0) {
        otherItem = currentItem.prev();
    }
    else {
        otherItem = currentItem.next();
    }

    if (otherItem.length > 0) {

        var otherLbl = $('#' + 'lbl_chapter_' + otherItem[0].id.substr(otherItem[0].id.lastIndexOf('_') + 1));

        var otherPosId = otherItem[0].childNodes[3].id;

        var otherPosChapId = otherItem[0].childNodes[1].childNodes[3].childNodes[3].id;

        // Getting the numbers
        var otherNumber = otherItem[0].innerText.trimStart().substr(0, otherItem[0].innerText.trimStart().indexOf(' '));
        var currentNumber = currentItem[0].innerText.trimStart().substr(0, currentItem[0].innerText.trimStart().indexOf(' '));

        currentLbl.text(currentLbl.text().replace(currentNumber, otherNumber));
        otherLbl.text(otherLbl.text().replace(otherNumber, currentNumber));

        // Getting the positions
        var intOtherPos = otherNumber.substr(otherNumber.lastIndexOf('.') + 1);
        var intCurrPos = currentNumber.substr(otherNumber.lastIndexOf('.') + 1);

        // Getting current and previous activity position hidden controls
        var hiddenActPosValue = $('input[id="' + currentPosId + '"]');
        var hiddenOthPosValue = $('input[id="' + otherPosId + '"]');

        var hiddenOthPosValue = $('input[id="' + otherPosChapId + '"]');

        // Exchanging the position hidden values
        hiddenActPosValue.val(intOtherPos);
        hiddenOthPosValue.val(intCurrPos);

        if (dir < 0) {
            currentItem.prev().insertAfter(currentItem);
        }
        else {
            currentItem.next().insertBefore(currentItem);
        }
    }
    else {
        console.log("It's already the last item in list");
    }
}

function moveItem(strElem, currentPosId, dir) {

    console.log("Moving UP " + strElem);

    // Getting the list elements
    var currentItem = $('#' + strElem);
    var otherItem
    if (dir < 0) {
        otherItem = currentItem.prev();
    }
    else {
        otherItem = currentItem.next();
    }

    if (otherItem.length > 0) {

        var otherPosId = otherItem[0].childNodes[3].id;
        let otherPosChapId;

        if (otherItem[0].childNodes[1].hasChildNodes()) {
            otherPosChapId = otherItem[0].childNodes[1].childNodes[3].childNodes[3].id;
        }


        // Getting the numbers
        var otherNumber = otherItem[0].innerText.trimStart().substr(0, otherItem[0].innerText.trimStart().indexOf(' '));
        var currentNumber = currentItem[0].innerText.trimStart().substr(0, currentItem[0].innerText.trimStart().indexOf(' '));

        // Getting the positions
        var intOtherPos = otherNumber.substr(otherNumber.lastIndexOf('.') + 1);
        var intCurrPos = currentNumber.substr(otherNumber.lastIndexOf('.') + 1);

        // Getting current and previous activity position hidden controls
        var hiddenActPosValue = $('input[id="' + currentPosId + '"]');
        var hiddenOthPosValue = $('input[id="' + otherPosId + '"]');
        var hiddenOthPosSubchValue;

        if (otherPosChapId) {
            hiddenOthPosSubchValue = $('input[id="' + otherPosChapId + '"]');
        }

        // Exchanging the position hidden values
        hiddenActPosValue.val(intOtherPos);
        hiddenOthPosValue.val(intCurrPos);

        if (hiddenOthPosSubchValue) {
        hiddenOthPosSubchValue.val(intCurrPos);
        }

        var elementText = currentItem[0].innerHTML.replace(currentNumber, otherNumber);
        currentItem[0].innerHTML = elementText;

        var otherText = otherItem[0].innerHTML.replace(otherNumber, currentNumber);
        otherItem[0].innerHTML = otherText;

        if (dir < 0) {
            currentItem.prev().insertAfter(currentItem);
        }
        else {
            currentItem.next().insertBefore(currentItem);
        }
    }
    else {
        console.log("It's already the last item in list");
    }
}


function runSearchers(ids, types) {
    let field;
    for (var i = 0; i < ids.length; i++) {
        field = document.getElementById(ids[i]);
        FilterActivityList(field, types[i])
    }
}

//word description
//common values
var target;
var sumerText;

function setCurrentStoredValues(dest, src) {
    dest.innerHTML = '';
    dest.innerHTML = src.firstElementChild.value;
}

function getTextValues(text, element) {

    element.firstElementChild.value = text;
}

function changeSummernoteTarget(element) {
    target = element;
    setCurrentStoredValues(sumerText, target);

}

(function () {
    //load with document
    setSumernoteEvent();


    function setSumernoteEvent() {
        let summerBox = document.getElementById('summernoteBox');
        sumerText = summerBox.nextElementSibling.getElementsByClassName("note-editable card-block")[0];

        sumerText.addEventListener('input', function () {
            getTextValues(sumerText.innerHTML, target);
        });
    }

})();