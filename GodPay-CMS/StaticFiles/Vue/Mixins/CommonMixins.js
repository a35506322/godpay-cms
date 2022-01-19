import { GetListOfFunctionFilter } from '../Services/IpassService.js'

export default {
    components: {
        "p-datatable": primevue.datatable,
        "p-column": primevue.column,
    },
    data: function () {
        return {
            funcs: [],
        }
    },
    methods: {
        GetListOfFunctionFilter: async function (query) {
            try {
                const response = await GetListOfFunctionFilter(query).then(response => response);
                const status = response.status;
                if (status === 200) {
                    const data = response.data;
                    const code = data.rtnCode;
                    switch (code) {
                        case 200:
                            if (data.rtnData.length > 0) {
                                this.funcs = data.rtnData[0].functions;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (exception) {
                console.log(exception)
            }
        },
    }  
}