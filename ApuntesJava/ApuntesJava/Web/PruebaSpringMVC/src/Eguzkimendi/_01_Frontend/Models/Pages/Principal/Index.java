package Eguzkimendi._01_Frontend.Models.Pages.Principal;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class Index {

    @GetMapping("/")
    public ModelAndView index(Model model) {
        var layout = new ModelAndView("index");
        return layout;
    }

}
