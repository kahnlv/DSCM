function contains(array, obj) {
    var i = array.length;
    while (i--) {
        if (array[i] == obj) {
            return true;
        }
    }
    return false;
}
function deleteArr(array, obj) {
    var i = array.length;
    while (i--) {
        if (array[i] === obj) {
            array[i] = "";
        }
    }
}