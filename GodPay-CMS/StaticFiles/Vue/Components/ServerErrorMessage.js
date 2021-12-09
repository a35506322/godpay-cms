export default {
    props:['attr'],
    data: function () {
        return {
            errorMessages:[]
        }
    },
    mounted: function () {
        this.$emitter.on('ServerErrorMessages', modelStateError => {
            this.errorMessages = modelStateError[this.attr]
        })
    },
    template: `
                <template v-for="(errorMessage,index) in errorMessages" v-bind:key="'key'+index">
                    <span role="alert" class="invalid-feedback">{{errorMessage}}</span>
                </template>
               ` 
}