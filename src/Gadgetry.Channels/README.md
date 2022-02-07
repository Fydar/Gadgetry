# ![Project icon](https://raw.githubusercontent.com/Fydar/Gadgetry/main/src/Gadgetry.Channels/icon@46x46.png) Gadgetry.Channels

A **channel** represents the flow of data from one Gadget to another.

![A gadget that utilises a producer and a consumer in order to aggregate data.](https://raw.githubusercontent.com/Fydar/Gadgetry/main/img/channels-parent.svg)

The producer gadget in this sample simply counts up to a value and writes to a channel every number in the sequence.

![The producer gadget that counts up to 1,000 and writes all numbers in the sequence to the channel.](https://raw.githubusercontent.com/Fydar/Gadgetry/main/img/channels-producer.svg)

And finally, the consumer gadget will read from the input channel and average all of the values together.

![The consumer gadget that reads all values from channel and outputs the average.](https://raw.githubusercontent.com/Fydar/Gadgetry/main/img/channels-consumer.svg)
