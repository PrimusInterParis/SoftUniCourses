function add(first) {
    let sum = first;

    function addFunc(second) {
        sum += second;

        return addFunc;
    }

    addFunc.toString = () => {
        return sum;
    }

    return addFunc;


}


let result = add(1)(2)(3)(4).toString();