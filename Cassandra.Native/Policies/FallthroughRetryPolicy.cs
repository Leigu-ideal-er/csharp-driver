using System;
using System.Collections.Generic;
using System.Text;

namespace Cassandra
{
    /**
     * A retry policy that never retry (nor ignore).
     * <p>
     * All of the methods of this retry policy unconditionally return {@link RetryPolicy.RetryDecision#rethrow}.
     * If this policy is used, retry will have to be implemented in business code.
     */
    public class FallthroughRetryPolicy : RetryPolicy
    {

        public static readonly FallthroughRetryPolicy INSTANCE = new FallthroughRetryPolicy();

        private FallthroughRetryPolicy() { }


        /**
         * Defines whether to retry and at which consistency level on a read timeout.
         *
         * @param cl the original consistency level of the read that timeouted.
         * @param requiredResponses the number of responses that were required to
         * achieve the requested consistency level.
         * @param receivedResponses the number of responses that had been received
         * by the time the timeout exception was raised.
         * @param dataRetrieved whether actual data (by opposition to data checksum)
         * was present in the received responses.
         * @param nbRetry the number of retry already performed for this operation.
         * @return {@code RetryDecision.rethrow()}.
         */
        public RetryDecision OnReadTimeout(ConsistencyLevel cl, int requiredResponses, int receivedResponses, bool dataRetrieved, int nbRetry)
        {
            return RetryDecision.Rethrow();
        }

        /**
         * Defines whether to retry and at which consistency level on a write timeout.
         *
         * @param cl the original consistency level of the write that timeouted.
         * @param writeType the type of the write that timeouted.
         * @param requiredAcks the number of acknowledgments that were required to
         * achieve the requested consistency level.
         * @param receivedAcks the number of acknowledgments that had been received
         * by the time the timeout exception was raised.
         * @param nbRetry the number of retry already performed for this operation.
         * @return {@code RetryDecision.rethrow()}.
         */
        public RetryDecision OnWriteTimeout(ConsistencyLevel cl, string writeType, int requiredAcks, int receivedAcks, int nbRetry)
        {
            return RetryDecision.Rethrow();
        }

        /**
         * Defines whether to retry and at which consistency level on an
         * unavailable exception.
         *
         * @param cl the original consistency level for the operation.
         * @param requiredReplica the number of replica that should have been
         * (known) alive for the operation to be attempted.
         * @param aliveReplica the number of replica that were know to be alive by
         * the coordinator of the operation.
         * @param nbRetry the number of retry already performed for this operation.
         * @return {@code RetryDecision.rethrow()}.
         */
        public RetryDecision OnUnavailable(ConsistencyLevel cl, int requiredReplica, int aliveReplica, int nbRetry)
        {
            return RetryDecision.Rethrow();
        }
    }

}