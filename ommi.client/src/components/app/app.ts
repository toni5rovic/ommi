import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import MenuComponent from '../navmenu/navmenu.vue'
import HelloWorld from '../HelloWorld.vue'

@Component({
  components: { MenuComponent }
})

export default class AppComponent extends Vue {
  name = 'App'

  components = {
    HelloWorld
  }

  data = () => ({
    //
  })
}
