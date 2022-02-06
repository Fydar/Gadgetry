<h1>
<img src="./icon.png" width="60" height="60" align="left" />
Gadgetry.Channels
</h1>

A **channel** represents the flow of data from one Gadget to another.

<p align="center">
  <img src="../../img/channels-parent.svg" alt="A gadget that utilises steps."/>
  <sup><i>A gadget that utilises a <b>producer</b> and a <b>consumer</b> in order to aggregate data.</i></sup>
</p>

The producer gadget in this sample simply counts up to a value and writes to a channel every number in the sequence.

<p align="center">
  <img src="../../img/channels-producer.svg" alt="A gadget that utilises steps."/>
  <sup><i>The producer gadget that counts up to <b>1,000</b> and writes all numbers in the sequence to the channel.</i></sup>
</p>

And finally, the consumer gadget will read from the input channel and average all of the values together.

<p align="center">
  <img src="../../img/channels-consumer.svg" alt="A gadget that utilises steps."/>
  <sup><i>The consumer gadget that reads all values from channel and outputs the average.</i></sup>
</p>
