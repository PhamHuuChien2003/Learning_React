// import the library
import { library } from '@fortawesome/fontawesome-svg-core'

// import your icons
import { fab } from '@fortawesome/free-brands-svg-icons'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { far } from '@fortawesome/free-regular-svg-icons'
import { faTwitter, faFontAwesome } from '@fortawesome/free-brands-svg-icons'


import './App.css';
import Nav_middle from './Nav/Nav_middle/Nav_middle'


function App() {
  return (
    <div className="App">
     <Nav_middle/>
    </div>
  );
}

export default App;
library.add(fab, fas, far,faTwitter, faFontAwesome)


