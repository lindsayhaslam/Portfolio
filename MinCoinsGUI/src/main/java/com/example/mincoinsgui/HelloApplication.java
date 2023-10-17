package com.example.mincoinsgui;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;  // Needed for ActionListener
//class GUI
class GUI extends JFrame {
    //Fields or attributes
    private JTextField amountTF = new JTextField(3);
    private JLabel quarterLBL = new JLabel("");
    private JLabel dimeLBL = new JLabel("");
    private JLabel nickelLBL = new JLabel("");
    private JLabel pennyLBL = new JLabel("");


    //Constructor
    public GUI() {
        // 1.Create/initialize components
        JButton calculateBtn = new JButton("Calculate");  //Declares and initializes Calc button
        JButton clearBtn = new JButton("Clear");  //Declares and initializes Clear button
        calculateBtn.addActionListener(new CalculateBtnListener()); //Creates an association between button and object
        clearBtn.addActionListener(new ClearBtnListener()); //Creates an association between button and object
        //add clear listener
        amountTF.addActionListener(new CalculateBtnListener());

        // 2.Create content panel, set layout
        JPanel content = new JPanel();
        content.setLayout(new GridLayout(6, 2, 2, 2));
        content.setBackground(new Color(181, 194, 103));

        //3. Create labels for user input and coins
        content.add(new JLabel("Enter Change (1-99)"));
        content.add(amountTF);

        //Quarters
        content.add(new JLabel("Quarters"));
        content.add(quarterLBL);
        //Dimes
        content.add(new JLabel("Dimes"));
        content.add(dimeLBL);
        //Nickels
        content.add(new JLabel("Nickels"));
        content.add(nickelLBL);
        //Pennies
        content.add(new JLabel("Pennies"));
        content.add(pennyLBL);

        //4. Create buttons
        content.add(calculateBtn);
        content.add(clearBtn);

        // 5. Set this window's attributes, and pack it.
        setContentPane(content);
        pack();                               // Layout components.
        setTitle("Minimum Coins");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);          // Center window.

    } //end of constructor

    //Clear button listener
    class ClearBtnListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent e) {
            //clear all fields
            quarterLBL.setText("");
            dimeLBL.setText("");
            nickelLBL.setText("");
            pennyLBL.setText("");
            amountTF.setText("");
            //setup cursor to text field
            amountTF.requestFocus();
        }
    }

    // Calculate button listener
    class CalculateBtnListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent object) {
            try {
                System.out.println("object");

                //Get the value from the amount textfield.
                String amountStr = amountTF.getText();
                //Store amountStr in int variable
                int amount = Integer.parseInt(amountStr);

                //Initialize variables at 0
                int quarters = 0;
                int dimes = 0;
                int nickels = 0;
                //find quarters
                while (amount >= 25) {
                    amount = amount - 25;
                    quarters = quarters + 1;
                }
                //find dimes
                while (amount >= 10) {
                    amount = amount - 10;
                    dimes = dimes + 1;
                }
                //find nickel
                if (amount >= 5) {
                    amount = amount - 5;
                    nickels = nickels + 1;
                }

                //Update coin labels and convert to string
                quarterLBL.setText("" + quarters);
                dimeLBL.setText("" + dimes);
                nickelLBL.setText("" + nickels);
                pennyLBL.setText("" + amount);

                //Setup input field for next amount
                amountTF.requestFocus();
                amountTF.selectAll();
            }//end of try

            catch (NumberFormatException f) {
                amountTF.setText("Invalid");
                amountTF.requestFocus();
                amountTF.selectAll();
            }
        }
    }
}

