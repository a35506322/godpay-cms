export default {
    props:['attr'],
    data: function () {
        return {
            errorMessage:''
        }
    },
    mounted: function () {
        this.$emitter.on('ServerErrorMessages', modelState => {
            console.log(modelState);
            this.errorMessage = modelState[this.attr][0]
        })
    },
    template: `<span role="alert" class="invalid-feedback">{{errorMessage}}</span>`
}