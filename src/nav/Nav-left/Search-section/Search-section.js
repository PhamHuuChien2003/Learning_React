import "./Search-section.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export default function Search_section() {
	return(
		<>
		    <div class="search-section">
				<FontAwesomeIcon icon="fa-solid fa-magnifying-glass" style={{color: "#585c65",}} class="icon-search"/>
				<input type="text" placehoder="Search Facebook"/>
			</div>
		</>
	)
}
