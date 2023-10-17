module com.example.mincoinsgui {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.desktop;


    opens com.example.mincoinsgui to javafx.fxml;
    exports com.example.mincoinsgui;
}