function getMain(obj) {
    if (obj.hasOwnProperty('d')) {
        return obj.d;
    }
    else {
        return obj;
    }
}